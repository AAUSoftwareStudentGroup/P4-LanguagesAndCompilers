import os

files = os.listdir()
for string file in files:
	if file.endswith(".tang"):
		output = subprocess.check_output(['dotnet','run',file])
		print output