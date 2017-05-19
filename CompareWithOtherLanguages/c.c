void wait() {
	for(long long i = 0; i < 3200000; i++) {}
}

void main() {
  (*(volatile char *)((0x04) + 0x20)) |= 1<<5;
  
  while(1) {
    (*(volatile char *)((0x05) + 0x20)) |= 1<<5;
    wait();
    (*(volatile char *)((0x05) + 0x20)) &= ~(1<<5);
    wait();
  }
}
