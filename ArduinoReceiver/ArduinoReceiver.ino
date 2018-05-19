// Controllers
int type  = 0;
int index = 0;
int value = 0;
char buf[4];

// Starting and end values
const char chStart = '[';
const char chEnd = ']';

// Color
int red = 0;
int green = 0;
int blue = 0;

void setup()
{
  Serial.begin(9600);
  pinMode(LED_BUILTIN, OUTPUT);
}

void loop()
{
  if (Serial.available() > 0)
  {
    switch (Serial.peek())
    {
      case chStart:
        Start();
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
  Serial.read();
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
