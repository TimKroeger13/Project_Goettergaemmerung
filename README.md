# Project_Goettergaemmerung
*Card Editor Program for private use* <br>

### What does Project Goetterdeammerung do:

This software is a card editor for the not yet released game "Götterdämmerung".
This software is therefore only for use with the correct data.
Use of the program by uninvolved persons is not intended.

### Understanding how a card editor works:

People who want to understand how to manipulate bitmaps in C#, perform blending procedures in a computationally optimized way, learn how conversion from text to bitmap works, or even create a map editor themselves are welcome to use the scrip as a source of information.

#### Needed Format:

| Struktur | Extradeck | Typ    | Name    | Untertyp | Zweihändig | Bedingung | Stats   | Text   | Flavor_text | Stufe           | Rasse           | Win    | Lose   | Druck_1 | Druck_2 | Druck_3 | Druck_4 |
| -------- | --------- | ------ | ------- | -------- | ---------- | --------- | ------- | ------ | ----------- | --------------- | --------------- | ------ | ------ | ------- | ------- | ------- | ------- |
| bool     | bool      | string | string  | string   | bool       | string    | string  | string | string      | string          | string          | string | string | integer | integer | integer | integer |
