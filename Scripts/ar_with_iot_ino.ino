#define BLYNK_PRINT Serial
#define relay D0
#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <BlynkSimpleEsp8266.h>
char auth[] = "your_authentication_token";
char ssid[] = "your_ssid_name";
char pass[] = "your_ssid_password";
BLYNK_WRITE(V1)
{
  int pinValue = param.asInt(); // assigning incoming value from pin V1 to a variable
  digitalWrite(relay,pinValue);
    if(pinValue==1)
  {
    Serial.println("ON");
  }
  if(pinValue==0)
  {
    Serial.println("OFF");
  }
}
void setup()
{
  Serial.begin(9600);
  Blynk.begin(auth, ssid, pass);
  pinMode(relay, OUTPUT);
}

void loop()
{
  Blynk.run();
}
