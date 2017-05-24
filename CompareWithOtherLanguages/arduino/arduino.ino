void setup() {
  pinMode(LED_BUILTIN, OUTPUT);  
  Serial.begin(9600);
}

void wait() {
  for(long i = 0; i < 3200; i++) {
    for(volatile long j = 0; j < 1000; j++) {
      
    }
  }
  Serial.println("WAIT");
}

void loop() {
  digitalWrite(LED_BUILTIN, HIGH);
  wait();
  digitalWrite(LED_BUILTIN, LOW);
  wait();
  
}
