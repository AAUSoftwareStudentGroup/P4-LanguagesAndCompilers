import os, subprocess, os.path

files = os.listdir("tang/")
for file in files:
	if os.path.isfile("tang/" + file + ".c"):
		continue
	if file.endswith(".tang"):
		print "RUNNING FILE: " + file
		output = subprocess.check_output('cd ../../Compiler; dotnet run "../Compiler.Tests/Testfiles/tang/' + file + '" "../Compiler.Tests/Testfiles/tang/' + file + '.c"; exit 0', stderr=subprocess.STDOUT, shell=True)
		print 'cd ../../Compiler; dotnet run "../Compiler.Tests/Testfiles/tang/' + file + '" "../Compiler.Tests/Testfiles/tang/' + file + '.c"; exit 0'
		if "Exception" in output:
			print "FAILS. NO OUTPUT"