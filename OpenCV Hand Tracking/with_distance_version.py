import cv2
from cvzone.HandTrackingModule import HandDetector
import socket
import json
import math
import numpy as np

# Parameters
width, height = 1920, 1080

# Webcam
cap = cv2.VideoCapture(0)
cap.set(3, width) #3 is width
cap.set(4, height) #4 is height

# Hand Detector
# detector = HandDetector(maxHands=1, detectionCon=0.8) #previous 1 handed version
detector = HandDetector(maxHands=2, detectionCon=0.8) #2 handed version

# Communication
soc = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

# Z-depth Function
x = [900, 680, 550, 440, 345, 300, 260, 230, 205] # IMPORTANT: May need to adjust based on your camera
y = [15, 20, 25, 30, 35, 40, 45, 50, 55] # IMPORTANT: May need to adjust based on your camera
coff = np.polyfit(x, y, 2)

while(True):
    # Get the frame from webcam
    success, img = cap.read();

    # Hands
    hands, img = detector.findHands(img)

    data = []
    
    if hands:
        # Hand 1
        hand1 = hands[0]
        lmList1 = hand1["lmList"]
        # bbox1 = hand1["bbox"]
        centerPoint1 = [hand1['center'][0], height - hand1['center'][1]]
        handType1 = hand1["type"]
        fingersUp1 = detector.fingersUp(hand1);

        # Z-depth
        hand1X1, hand1Y1, hand1Z1 = lmList1[5]
        hand1X2, hand1Y2, hand1Z2 = lmList1[17]

        diag_distance = int(math.sqrt((hand1Y2 - hand1Y1)**2 + (hand1X2 - hand1X1)**2))
        A, B, C = coff
        distanceCM1 = A*diag_distance**2 + B*diag_distance + C

        lmList1_conv = []
        
        for lm in lmList1:
            lmList1_conv.extend([lm[0], height - lm[1], lm[2]])

        data.append({"lmList": lmList1_conv, "center": centerPoint1, "distance": distanceCM1, "fingersUp": fingersUp1, "type": handType1})

        if len(hands) == 2:
            # Hand 2
            hand2 = hands[1]
            lmList2 = hand2["lmList"]
            # bbox2 = hand2["bbox"]
            centerPoint2 = [hand2['center'][0], height - hand2['center'][1]]
            handType2 = hand2["type"]
            fingersUp2 = detector.fingersUp(hand2);

            # Z-depth
            hand2X1, hand2Y1, hand2Z1 = lmList2[5]
            hand2X2, hand2Y2, hand2Z2 = lmList2[17]

            diag_distance = int(math.sqrt((hand2Y2 - hand2Y1)**2 + (hand2X2 - hand2X1)**2))
            A, B, C = coff
            distanceCM2 = A*diag_distance**2 + B*diag_distance + C

            lmList2_conv = []

            for lm in lmList2:
                lmList2_conv.extend([lm[0], height - lm[1], lm[2]])

            data.append({"lmList": lmList2_conv, "center": centerPoint2, "distance": distanceCM2, "fingersUp": fingersUp2, "type": handType2})

        data_string = {"hands": data}
        json_string = json.dumps(data_string)
        soc.sendto(json_string.encode(), serverAddressPort)

    # Show captures
    cv2.imshow("Image", img)
    cv2.waitKey(1)