import cv2
from cvzone.HandTrackingModule import HandDetector
import socket
import json

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
        bbox1 = hand1["bbox"]
        centerPoint1 = hand1['center']
        handType1 = hand1["type"]

        lmList1_conv = []
        
        for lm in lmList1:
            lmList1_conv.extend([lm[0], height - lm[1], lm[2]])

        data.append({"lmList": lmList1_conv, "bbox": bbox1, "cp": centerPoint1, "type": handType1})

        if len(hands) == 2:
            # Hand 2
            hand2 = hands[1]
            lmList2 = hand2["lmList"]
            bbox2 = hand2["bbox"]
            centerPoint2 = hand2['center']
            handType2 = hand2["type"]

            lmList2_conv = []

            for lm in lmList2:
                lmList2_conv.extend([lm[0], height - lm[1], lm[2]])

            data.append({"lmList": lmList2_conv, "bbox": bbox2, "cp": centerPoint2, "type": handType2})

        data_string = {"hands": data}
        json_string = json.dumps(data_string)
        soc.sendto(json_string.encode(), serverAddressPort)

    # Show captures
    cv2.imshow("Image", img)
    cv2.waitKey(1)