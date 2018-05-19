// Controllers
int type  = 0;
int index = 0;
int value = 0;

// Color class
class Color
{
  public:
    int Red;
    int Green;
    int Blue;

    Color()
    {
      Red = Green = Blue = 0;
    }
};

// Generated Color
Color* color;

void setup()
{
  Serial.begin(9600);
  color = new Color();
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
    color->Red = value;
    type++;
  }
  else if (type == 1)
  {
    color->Green = value;
    type++;
  }
  else
  {
    color->Blue = value;
    type = 0;
    
    // TODO set leds to color
  }
}
