#define NATIVE_USB

void setup() {
    SerialUSB.begin(1);
}

void loop() {
    readLine();
    
    delay(200);
}

void sendData(String data) {
    SerialUSB.println(data);
}

void readLine() {
    String data = "";

    while (SerialUSB.available() > 0) {
        int input = SerialUSB.read();

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
