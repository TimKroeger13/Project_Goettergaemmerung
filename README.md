# Project_Goettergaemmerung
*Card Editor Program for private use* <br>

### What does Project Goetterdeammerung do:

This software is a card editor for the not yet released game "Götterdämmerung".
This software is therefore only for use with the correct data.
Use of the program by uninvolved persons is not intended.

### Understanding how a card editor works:

People who want to understand how to manipulate bitmaps in C#, perform blending procedures in a computationally optimized way, learn how conversion from text to bitmap works, or even create a map editor themselves are welcome to use the scrip as a source of information.

#### Needed Format:

| Struktur | Extradeck | Typ    | Name    | Untertyp | Zweihändig | Bedingung | Stats   | Text   | Flavor_text | Stufe           |     Rasse       | Win    | Lose   | Druck_1 | Druck_2 | Druck_3 | Druck_4 |
| -------- | --------- | ------ | ------- | -------- | ---------- | --------- | ------- | ------ | ----------- | --------------- | --------------- | ------ | ------ | ------- | ------- | ------- | ------- |
| Enum     | bool      | Enum   | string  |   Enum   |    Enum    |   Enum    | string  | string | string      | string          |     Enum        | string | string | integer | integer | integer | integer |

#### More spesific infos

**Struktur - Enum:**
- 'Normal' <-- Cards that are NOT monster cards
- 'Monster' <-- Monster Cards

**Extradeck - bool**
- 'TRUE' <-- Extra Deck
- '' <-- Not extra deck

**Typ - Enum** - This are the Card Backs and card color
- 'Action'
- 'Monster1'
- 'Monster2'
- 'Monster3'
- 'Monster4'
- 'Monster5'
- 'Equipment1'
- 'Equipment2'
- 'Equipment3'
- 'Companion'
- 'Library'
- 'Bar'
- 'Duell'
- 'Curse'
- 'Blessing'
- 'Disaster'
- 'Class'
- 'Tavern'
- 'Spell'

**Name - String** - Top Name of the Card

**Untertyp - Enum** - Card Text at the top of a card
- 'Artifact'
- 'Attribute' <-- Merkmal
- 'Weapon'
- 'Armor'
- 'Helmet'
- 'Shoes'
- 'CharacterTrait'
- 'Class'
- 'SpellDisaster' <-- Is special. Only in use for the Death
- 'SpellTrap'
- 'SpellFast'
- 'SpellNormal'
- 'Elixier'
- 'SpellCounter'
- 'SpellTrade'
- 'Blessing'
- 'Curse'
- 'Dwarf'
- 'Elf'
- 'Ork'
- 'Homunculus'
- 'Goblin'
- 'Giant'
- 'Demon'
- 'Tavern'
- 'Companion'
- '' <-- No header

**Zweihändig - Enum**
- 'Zweihändig' <-- It's a two handed weapon
- '' <-- Single handed

**Bedingung - Enum** - Discribtion which class can use this card
- 'OnlyPrist'
- 'NotPrist'
- 'OnlyBodybuilder'
- 'NotBodybuilder'
- 'OnlyVegan'
- 'NotVegan'
- 'OnlyLobbyist'
- 'NotLobbyist'
- 'OnlyBureaucrat'
- 'NotBureaucrat'
- 'OnlyVampire'
- 'NotVampire'
- 'OnlySoldier'
- 'NotSoldier'
- 'OnlyBureaucratLobbyist'
- '' <-- no condition

**Stats - String**

**Text - String**

**Flavor_text - String**

**Stufe - String**

**Rasse - Enum** <-- Race of monster cards
- 'Human'
- 'Soldier'
- 'Vampire'
- 'Animal'
- 'God'
- 'Monster' <-- Ungeheuer
- 'All'
- 'Rock'

**Win - String**

**Lose - String**

**Druck_1 - Integer**

**Druck_2 - Integer**

**Druck_3 - Integer**

**Druck_4 - Integer**

#### Some remarks to the Prints
- The number of cards get printed that is in the choosen print option

Format:
- Normal <-- Print Cards as singles. When there should be multiple copies of a card the png gets the number noted in the png name.
- Tabletop <-- Prints for every multiple version of a card a seperat png.
- Rebalance <-- Prints Cards singular and the they are ordert like in the CSV to make rebalancing more easy.














