// Controllers
int type  = 0;
int value = 0;

// Color
int red = 0;
int green = 0;
int blue = 0;

void setup()
{
  Serial.begin(9600);
}

void loop()
{
  if (Serial.available() > 0)
  {
    value = Serial.read();
    SetColor();
  }
}

void SetColor()
{
  if (type == 0)
  {
    red = value;
    type++;
  }
  else if (type == 1)
  {
    green = value;
    type++;
  }
  else
  {
    blue = value;
    type = 0;
    
    // TODO set leds to color
  }
}
