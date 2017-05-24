void wait() {
	for(int i = 0; i < 3200; i++) {
		for(int j = 0; j < 1000; j++) {}
	}
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
