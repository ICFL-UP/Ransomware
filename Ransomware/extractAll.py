import zipfile
import os

cwd = os.getcwd();
i = 0
for root, dirs, files in os.walk(cwd):
	for f in files:
		if f.endswith(".bin"):
			print(f);
			os.remove(os.path.join(root,f))
