import os, subprocess

files = os.listdir("tang/")
for file in files:
	if file.endswith(".tang"):
		print "RUNNING FILE: " + file
		output = subprocess.check_output('cd ../../Compiler; dotnet run "../Compiler.Tests/Testfiles/tang/' + file + '" "../Compiler.Tests/Testfiles/tang/' + file + '.c"; exit 0', stderr=subprocess.STDOUT, shell=True)
		if "Exception" in output:
			print "FAILS. NO OUTPUT"