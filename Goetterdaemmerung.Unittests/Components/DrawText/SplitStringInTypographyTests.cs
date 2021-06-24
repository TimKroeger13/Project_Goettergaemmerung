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
        [InlineData("",
            " (Regular)")]
        public void SplitString_StateUnderTest_ExpectedBehavior(string text, string expected)
        {
            var splitStringInTypography = CreateSplitStringInTypography();
            var result = splitStringInTypography.SplitString(
                text);
            var comparator = result.Select(s => $"{s.Word} ({s.Marker})");
            var comparatorOut = string.Join(';', comparator);

            /*

            var test1 = result.Select(s => s.Word);
            var test2 = result.Select(s => s.Marker);

            var x1 = JsonSerializer.Serialize(test1);
            var x2 = JsonSerializer.Serialize(test2);

            var checkifcorrect = JsonSerializer.Deserialize<string[]>(x1);
            var checkifcorrect2 = JsonSerializer.Deserialize<Project_Goettergaemmerung.Components.Model.Typography[]>(x2);

            var typographyMarker = new List<(string Word, Typography Marker)>();

            for (int i = 0; i < checkifcorrect.Length; i++)
            {
                typographyMarker.Add((checkifcorrect[i], checkifcorrect2[i]));
            }

            */

            //Linq verstehen - check
            //Fix Aufbau - check
            //Jason generieren
            //Auf Jason zugreifen / mocke

            comparatorOut.Should().BeEquivalentTo(expected);
        }
    }
}
