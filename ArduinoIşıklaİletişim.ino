#verici / transmitter
#gereksiz kod olabilir / there might be unnecessary code

int ledPin = 7;

char alphabet[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

void setup() {
  // put your setup code here, to run once:
  pinMode(ledPin, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:

  if (Serial.available() > 0)
  {
    char readCharacter;
    int sendDelay = 10;

    readCharacter = Serial.read();

    for (int i = 0; i < 26; i++)
    {
      if (readCharacter == alphabet[i])
      { 
        sendDelay = 100 * (i+1);
      }
    }

    digitalWrite(ledPin, HIGH);

    delay(sendDelay);

    digitalWrite(ledPin, LOW);
  }
}

#alıcı / receiver

int ldrPin = A1;
int signalThreshold = 300;

bool receiving = false;

unsigned long startTime;
unsigned long endTime;
unsigned long crnt;
unsigned long threshold = 75;

char alphabet[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

void setup() {
  // put your setup code here, to run once:
 
  Serial.begin(9600);

  int d1, d2, d3, d4, d5;

  d1 = analogRead(ldrPin);
  Serial.print("r1 ");
  Serial.println(d1);
  
  delay(1000);
  d2 = analogRead(ldrPin);
  Serial.print("r2 ");
  Serial.println(d2);

  delay(1000);
  d3 = analogRead(ldrPin);
  Serial.print("r3 ");
  Serial.println(d3);

  delay(1000);
  signalThreshold = (d1 + d2 + d3)/3;
  Serial.print("avg: ");
  Serial.println(signalThreshold);
  
}

bool evaluateLDR()
{
  int readValue = analogRead(ldrPin);

  if(readValue <= signalThreshold)
  {
    return false;
  }else
  {
    if(readValue >= (signalThreshold * 1.1))
    {   
      return true;
    }else
    {
      return false;
    }
  }
}

void loop() {
  // put your main code here, to run repeatedly:
  if (!receiving)
  {
    if (evaluateLDR())
    {
      receiving = true;
      startTime = millis();

    }
  } else
  {
    crnt = millis();

    if (crnt - startTime > threshold)
    {
      if (evaluateLDR() == false)
      {
        receiving = false;
        endTime = crnt;

        int alphIndex = ((endTime - startTime) / 100)-1;

        Serial.println(alphabet[alphIndex]);
      }
    }

    delay(1);
  }
}
