import os, subprocess

files = os.listdir('.')
for file in files:
	if file.endswith(".tang"):
		print "RUNNING FILE: " + file
		output = subprocess.check_output("cd ../../src/Compiler/ && dotnet run ../../docs/samples/" + file + "; exit 0", stderr=subprocess.STDOUT, shell=True)
		if "Exception" in output:
			print "FAILS"