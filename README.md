# literate
Literate program demo

Run the program:

$ dotnet run

This will render `template.html` in the build directory with the literate
program output within `content` contained within `Program.fs`.

The output is rendered back to the build directory as `index.html`.

If you wish to view the output and have python installed, change directory to
the build output and run a http server:

$ cd build
$ python -m http.server

Then navigate to a web browser and open a page to the appropriate localhost endpoint, typically http://localhost:8000

The files contained in wwwroot are taken verbatim and without change from the
[FSharp.Formatting](https://github.com/fsprojects/FSharp.Formatting/) repo (commit e04cf29).

I hope this program might serve as a demonstration of how to embed literate programming into a broader application.