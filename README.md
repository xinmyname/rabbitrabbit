# rabbitrabbit

## Find the rabbits!
* You will receive an input file with a grid of emojis.
* Your task is to find the location of all of the rabbit emojis, e.g. 🐇.
* The origin of the grid is (1,1) in the top-left.
* The first line of the input file contains the width and height of the grid, separated by an 'x', e.g. 100x100.
* The maximum width and height is 32768.
* The input file is UTF-8 encoded, with a BOM header. All line endings are LF (0x0A) only, no CR.
* Output the location of each rabbit as an x/y coordinate pair in parentheses, separated by a comma, e.g. (42,78).
* If the person running your program hits Ctrl-C while it's running, immediately stop processing and output "I stopped looking for rabbits."
* Optional: Sort the output by the y coordinate first, followed by the x coordinate.
* The source code for the grid generator is included in the **mkprarie** folder, if you want to generate your own grids.
* Fastest wins. Your time starts now.

## Sample Input

```txt
16x9
🌲🌱🌲🌳🌵🌲🟢🟢🌾🟢🟢🌵🐇🐇🌱🌵
🟢🟢🟢🟢🟢🌱🟢🟢🌱🟢🌱🌱🌵🟢🟢🟢
🟢🟢🟢🌿🌿🟢🟢🟢🟢🟢🟢🌾🌾🟢🌿🐇
🌱🌱🟢🌵🌱🌱🌲🌱🟢🟢🌿🌲🌵🌾🌿🟢
🌲🟢🌳🌾🟢🌳🟢🌿🌳🌾🌾🟢🟢🌲🟢🌾
🌲🌲🟢🌿🌾🌱🌾🟢🟢🌳🌾🌿🌵🟢🌱🟢
🟢🌲🟢🌲🌾🟢🌿🟢🐇🟢🌱🌳🟢🌳🌾🟢
🌳🟢🌲🟢🟢🐇🌲🟢🟢🟢🟢🟢🌲🌾🟢🟢
🌾🌳🌾🌵🟢🌲🌵🟢🌿🟢🌵🌾🟢🌿🟢🌱
```

## Sample Output
```txt
(13,1)
(14,1)
(16,3)
(9,7)
(6,8)
```
