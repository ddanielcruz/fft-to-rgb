// Settings
// Start and end chars
const char chStart = '[';
const char chEnd = ']';

// Types
const char rT = 'R';
const char gT = 'G';
const char bT = 'B';

// Controllers
char buf[4];
char type;
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

    Color(int red, int green, int blue)
    {
      Red = red;
      Green = green;
      Blue = blue;
    }

    void reset()
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
  // TODO receive just one byte instead of three representing an int
  if (Serial.available() > 0)
  {
    switch (Serial.peek())
    {
      case chStart:
        Start();
        break;
      
      case rT: case gT: case bT:
        type = Serial.read();
        break;

      case chEnd:
        Serial.read();
        value = atoi(buf);
        SetColor();
        break;

      default:
        buf[index++] = Serial.read();
        buf[index] = '\n';
    }
  }
}

void Start()
{
  index = 0;
  color->reset();
  Serial.read();
}

void SetColor()
{
  if (type == 'R')
    color->Red = value;
  else if (type == 'G')
    color->Green = value;
  else
  {
    color->Blue = value;
    // TODO set leds to color
  }
}
