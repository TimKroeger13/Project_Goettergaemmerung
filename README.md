# Project_Goettergaemmerung
Card Editor Program for private use - *Documentation language is german.* <br>
#### Aufgabe des Scripts:

Ziel dieses Programmes ist es aus einen gegebenen *.ods* File, welcher auf der Basis von LibreOffice Calc erstellt wurde, einzulesen und mit
den darin enthalten Informationen Karten zu generieren, welche in einen Ordner freier Wahl als Bilddatei (*.png*) gespeichert werden. 

#### Teilabschnitte (Goals):

1. Kreieren einer leeren (weißen) Bilddatei, welche die richtigen Anzahl von Pixel als Breite und Höhe besitzt.
2. Speichern dieser Datai als .png in einen gewählten Ordner.
3. Einladen meherer Bilddatein mit Transparenzwerten (.png) welche exakt übereinder gelegt werden.
4. Blenden der einzelnen Ebenen. Dabei soll erstmal die Standart blend Formel verwenden werden, bei der für jeden Pixel mit Hilfe der Transparens berechnet
wird, welchen Farb-Wert der Ausgaspixel besitzen soll.
5. *Optimal:* Erweitern durch die Muliplkations blend Formel um Kartentextur generien zu können. 
6. Zugriff auf den .ods File erhalten. Den ersten Wert jeder Spalte einlesen und Variablen zuordnen.
7. Test Texte gewählter Variablen auf die Bilddatein als Grafik Element in gewählter Schriftart schreiben.
8. Textfenster erstellen, welches ab einen Schwellenwert einen Zeilenumbruch im Text erstellt damit der Text nicht über den Rand der Grafik geschrieben wird.
9. *Optimal:* Dieses Textfenster nicht nur für eine Rechteckige Textbox erstellen sondern auch für ein Trapezform.
10. Dynamisches einfügen der "Trennlinie.png" erstellen, damit dieses Bild immer unterhalb der Überschrift eingefügt wird.
11. Orte und Größe der Textboxen bestimmen. Schwierigkeit sind hierbei die Text Box der Überschrieft und die des Haupt Textes da beide keine Festen Kordinaten in Pixel 
für jeweils eines ihrer Enden besitzt.
12. Die Textbox so konfigurien das einzenle Zeilen zentriert dargestellt werden können, während andere links zentrisch angeordnet sind.
13. Erkennen von keywords und anpassen dieser. Es muss eine Liste von Keywords erstellt werden welche Text strings enthält die im Text "fett" geschrieben werden sollen.
14. Schriftgröße des zu schreibenen Textes für jede Textbox berechnen. Dazu braucht es ein Funktion die berrechnen kann ob ein Text in einer gewählten Schriftgröße
vollständig in eine Textbox einer bekannten Größe angezeigt werden kann. Es gibt hierbei einen Standartwert. Wenn der Text mit diesen Standartwert nicht in die 
Textbox passt soll dieses Funktion rekusive mit einer 1 Pixel kleiner Schriftgröße ausgeführt werden bis aller Text in der gewünschte Textbox passt.
15. Test button erstellen welcher allein aus den in einer belibiegen Zeile des sorce .ods files enhalten Informationen eine Karte kreiert.
16. Schritt 15 mit meheren Karten auf einmal möglich machen.
17. User Interface erstellen.
18. User Interface so anbinden das durch Eingabefelder alles gesteuert werden kann.

#### Hauptfunktionen des Scripts welche benötigt werden:
- Funktion die ein Bild in c# kreieren kann; nach vorgabe von bestimmten Pixel größen.
- Funktion welche eine Bilddatei Speichern kann.
- Funktion die weitere Biler auf den so kreierten Canvas legen kann.
- Bleder funktion für normale transparentwerte.
- Blender funktion für multipling blending.
- Funktion welche alle Date ein bestimmten Zeile der .ods einlädt.
- Funktion die Text zu Grafik umwandelt und sie auf den canvas schreiben kann.
- Funktion für Text Fenster.
- Funktion für nicht quadratisches Text Fenserter.
- Funktion zum ermitteln des Zeilenumbruches des gewählten Text Fensters.
- Funktion zum erkennen von keyword und anpassen der keyword in markdown oder einen anderen Auszeichnungssprache.
- Funktion die berechnet ob ein Text in eine Gewählte Text box passt oder nicht.

#### User Interface:

- Eingabefeld erstellen in dem man den .ods File auswählt welcher verwendet werden soll.
- Eingabefeld erstellen so man anwählt in welchen Ordner die erstellten .png gespeichert werden sollen.
- Eingabefeld erstellen in dem man wählen kann welche Druckeinstellungen (Anzahl der Karten) man wählen will.
- Buttom um die gewählten einstellungen auszuführen.

#### Mögliche Probleme und deren Lösung:
- Wenn die .ods Datei die von LibreOffice Calc geneiert werden sollten zuviele Probleme verursachen kann man auf Tabstopp Files als Ersatz zugreifen die man mit libreOffice 
alternative generieren kann.
- Einer der schwersten Herrausforderungen kann es sein zu ermitteln wann ein Zeilenumbruch stattfinden soll. Dies kann nähmlich nicht an den einzelnen Bustaben ermittelt werden
da diese unterschriedliche breiten haben, sie Schriftart abhängig sind und Fett und nicht fette Buchstaben unterschiedlich breit sind. Außerdem ist dies schwer
zu ermitteln da es sich dabei um Grafikparamter handelt. Dadurch muss man entweder wissen wieviele Pixel groß jeder Buchstabe in der gewählte Schriftart ist, oder
irgendwie überprüfen können ob der Text den Rand der Textbox erreicht hat oder nicht. Vielleicht gibt es hier auch einen leichten Weg der direkt in die Texbox
integiert werden kann.
- Das gleiche gilt auch für die Frage ob ein gewählter Text in einer gewählten Schriftgröße in einer Textbox passt oder nicht. Wenn es möglich ist zu erkennen wann ein
Zeilenumbruch stattfindet oder nicht kann man dies auch als Information benutzen um herauszufinden ob eine Textbox passt oder nicht passt, wenn man weiß wie Breit eine
Zeilen der gewählten Schriftart ist. Auch hier währe es sehr praktisch wenn leichten Weg gibt dies direkt in die Textbox zu integrieren.

#### Aufbau der Excel und Formatierungen:

|Struktur|Extradeck|  Typ   |  Name  |Untertyp|Zweihändig|Bedingung|  Stats |  Text  |Flavor_text|  Stufe          |  Rasse      |   Win  |  Lose  |Druck_1|Druck_2|Druck_3|Druck_4|
|--------|---------|--------|--------|--------|----------|---------|--------|--------|-----------|------------------|---------------|--------|--------|-------|-------|--------|--------|
|bool    |   bool  |  string|string  | string |bool      |string   |string  | string |  string   |string         |string          |string  |string  |integer|integer|integer|integer|
|        |         |        |centert | centert|centert  |centert  |centert  |        |           |+ Rasse centert |+ Stufe centert |        |        |  |      |       |       |
|        |         |        |fett   |        |          |          |      |        |     kursive  |+ Rasse fett |+ Stufe fett |        |        |  |      |       |       |
