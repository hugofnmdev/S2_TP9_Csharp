program = Program.cs
outputname = Output.exe

compile :
	@read -r -p "Please input name of the file with the .cs extension : " filetocompile; \
	csc $(program) $$filetocompile -out:$(outputname); \
	echo "Compilation finished by the compiler :) (hapi face)"

run :
	@read -r -p "Please input name of the file with the .cs extension : " filetocompile; \
	csc $(program) $$filetocompile -out:$(outputname); \
	mono $(outputname)

clean :
	@rm $(outputname)
	@echo "File has been removed. KGB-FileRemover PRO VERSION (c) (большая шутка, лол !)"