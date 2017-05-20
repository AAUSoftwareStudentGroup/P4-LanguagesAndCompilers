void setup() {
  pinMode(LED_BUILTIN, OUTPUT);
}

void wait() {
  for(long long i = 0; i < 32000000; i++) {
  
  }
}

void loop() {
  digitalWrite(LED_BUILTIN, HIGH);
  wait();
  digitalWrite(LED_BUILTIN, LOW);
  wait();
  
}
