// If you are using a non ARM CPU (Arduino Uno, Arduino Mega, ..)
#define SERIAL_USB

void setup() {
  // You can choose any baud rate, just need to also change it in Unity.
  Serial.begin(250000);
  while (!Serial); // wait for Leonardo enumeration, others continue immediately
}

void loop() {
  sendData("Hello World!");
  
  delay(5); // Choose your delay having in mind your ReadTimeout in Unity
}

void sendData(String data){
  Serial.println(data); // need a end-line because wrmlh.csharp use readLine method to receive data
}

void receiveData() {
  String incomingData = Serial.readString();
  digitalWrite(13, incomingData == "" ? LOW : HIGH );
}
