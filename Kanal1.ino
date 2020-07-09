
int ledPin = 7;

void setup() {
  pinMode(7, OUTPUT);
  digitalWrite(ledPin, HIGH);
}

void loop() {
digitalWrite(ledPin, HIGH);
delay(250);
digitalWrite(ledPin, LOW);
delay(250);

}
