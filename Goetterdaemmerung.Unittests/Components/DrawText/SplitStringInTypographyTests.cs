using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.DrawText;
using System;
using Xunit;
using System.Linq;
using FluentAssertions;
using System.Text.Json;
using System.Collections.Generic;
using Project_Goettergaemmerung.Components.Model;
using Project_Goettergaemmerung.ExtensionMethods;

namespace Unittests.Components.DrawText
{
    public class SplitStringInTypographyTests
    {
        public SplitStringInTypographyTests()
        {
        }

        public SplitStringInTypography CreateSplitStringInTypography()
        {
            return new SplitStringInTypography();
        }

        [Theory]
        [InlineData("Große Muskeln: +2/0 gegen Spieler\n\nNichts dahinter: -1/0 gegen Monster",
            "Große (Bold);Muskeln: (Bold);+2/0 (Bold);gegen (Regular);Spieler (Regular);<br> (LineBreak);<br> (LineBreak);Nichts (Bold);dahinter: (Bold);-1/0 (Bold);gegen (Regular);Monster (Regular)")]
        [InlineData("", " (Regular)")]
        [InlineData("Dein Bush brennt!\nEin Zeichen Gottes?\nWürfel mit einen D6.\nSolltest du eine 6 würfeln erhälst du \"Auserwählt\" (Extra Deck).\nWerfe einen weitere D6 für jedes Faith, das du besitzt.\nSolltest du es nicht schaffen setzt du eine Runde aus, um das Feuer zu löschen.",
                "Dein (Regular);Bush (Regular);brennt! (Regular);<br> (LineBreak);Ein (Regular);Zeichen (Regular);Gottes? (Regular);<br> (LineBreak);Würfel (Regular);mit (Regular);einen (Regular);D6. (Bold);<br> (LineBreak);Solltest (Regular);du (Regular);eine (Regular);6 (Bold);würfeln (Regular);erhälst (Regular);du (Regular);\"Auserwählt\" (Bold);(Extra (Italic);Deck). (Italic);<br> (LineBreak);Werfe (Regular);einen (Regular);weitere (Regular);D6 (Bold);für (Regular);jedes (Regular);Faith, (Bold);das (Regular);du (Regular);besitzt. (Regular);<br> (LineBreak);Solltest (Regular);du (Regular);es (Regular);nicht (Regular);schaffen (Regular);setzt (Regular);du (Regular);eine (Regular);Runde (Regular);aus, (Regular);um (Regular);das (Regular);Feuer (Regular);zu (Regular);löschen. (Regular)")]
        [InlineData("Wenn du eine 6 wuerfelst, hat diese Waffe stattdessen +4/0.",
            "Wenn (Regular);du (Regular);eine (Regular);6 (Bold);wuerfelst, (Regular);hat (Regular);diese (Regular);Waffe (Regular);stattdessen (Regular);+4/0. (Bold)")]
        [InlineData("Testtext der D20 Wörter wie Vampirismus und vampirismus. oder / + - | passieren enthält. Dies sollte aber nicht mit den Wort passiere oder passierst oder Todpassieren verwechselt werden. (test) text passiere",
             "Testtext (Regular);der (Regular);D20 (Bold);Wörter (Regular);wie (Regular);Vampirismus (Bold);und (Regular);vampirismus. (Bold);oder (Regular);/ (Regular);+ (Bold);- (Bold);| (Bold);passieren (Bold);enthält. (Regular);Dies (Regular);sollte (Regular);aber (Regular);nicht (Regular);mit (Regular);den (Regular);Wort (Regular);passiere (Bold);oder (Regular);passierst (Bold);oder (Regular);Todpassieren (Bold);verwechselt (Regular);werden. (Regular);(test) (Regular);text (Regular);passiere (Bold)")]
        [InlineData("Erhalte 1 Ausrüstungskarte (Gewöhnlich), 1 Ausrüstungskarte (selten) und wähle 1 (Legendär). 3",
            "Erhalte (Regular);1 (Bold);Ausrüstungskarte (Regular);(Gewöhnlich), (Bold);1 (Bold);Ausrüstungskarte (Regular);(selten) (Bold);und (Regular);wähle (Regular);1 (Bold);(Legendär). (Bold);3 (Bold)")]
        [InlineData("Test 3 (Extra Deck) D1 Monster haben +1 / -2 wenn (Bei Nacht +2/+3) | du es schafft bei einen D8 eine (Extra Deck) 4. Erhält einen (bonus von faith. More Text37aD8",
            "Test (Regular);3 (Bold);(Extra (Italic);Deck) (Italic);D1 (Bold);Monster (Regular);haben (Regular);+1 (Bold);/ (Regular);-2 (Bold);wenn (Regular);(Bei (Regular);Nacht (Regular);+2/+3) (Bold);| (Bold);du (Regular);es (Regular);schafft (Regular);bei (Regular);einen (Regular);D8 (Bold);eine (Regular);(Extra (Italic);Deck) (Italic);4. (Bold);Erhält (Regular);einen (Regular);(bonus (Regular);von (Regular);faith. (Bold);More (Regular);Text37aD8 (Bold)")]
        [InlineData("Nur Text ohne bold",
            "Nur (Regular);Text (Regular);ohne (Regular);bold (Regular)")]
        public void SplitString_StateUnderTest_ExpectedBehavior(string text, string expected)
        {
            var test3 = text.StringSplitter();

            var splitStringInTypography = CreateSplitStringInTypography();
            var result = splitStringInTypography.SplitString(
                text);
            var comparator = result.Select(s => $"{s.Word} ({s.Marker})");
            var comparatorOut = string.Join(';', comparator);

            comparatorOut.Should().BeEquivalentTo(expected);
        }
    }
}
