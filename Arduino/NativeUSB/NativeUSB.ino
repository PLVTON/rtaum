// If you are using an ARM CPU (Arduino DUE, Arduino M0, ..)
#define NATIVE_USB

void setup() {
  // The baud rate is irrevelant when using NATIVE_USB
  SerialUSB.begin(1);
}

void loop() {
  sendData("Hello World!");
  
  delay(5); // Choose your delay having in mind your ReadTimeout in Unity
}

void sendData(String data){
  SerialUSB.println(data); // need a end-line because wrmlh.csharp use readLine method to receive data
}

void receiveData() {
  String incomingData = SerialUSB.readString();
  digitalWrite(13, incomingData.Equals("") ? LOW : HIGH );
}
