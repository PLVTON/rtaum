#define SERIAL_USB

bool ledStatus = false;

void setup() {
    // Make sure the baud rate is the same as in Unity
    Serial.begin(250000);
    while (!Serial);
}

void loop() {
    readLine();
    
    delay(200);
}

void sendData(String data) {
    Serial.println(data);
}

void readLine() {
    String data = "";

    while (Serial.available() > 0) {
        int input = Serial.read();

        if (input == '\n') {
            data.trim();
            processData(data);
            data = "";
        } else {
            data = data + char(input);
        }
    }
}

void processData(String readData) {
    // readData is the data received from Unity

    // If you want to send some data back
    sendData(readData);
}
