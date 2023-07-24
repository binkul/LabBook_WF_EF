using LabBook_WF_EF.Dto;
using LabBook_WF_EF.EntityModels;
using System;

enum NormTests
{
    Empty,
    Anti_Flash,
    Clemens,
    Cone_plate,
    Drying_time,
    Solids,
    Condensation_chamber,
    Salt_chamber,
    UV_chamber,
    Hiding,
    Visual_aspect,
    Vapour_permeablitiy,
    Stains,
    Gloss,
    Adhession,
    Hiding_power,
    Flow_limit,
    Scrubing,
    Yelowness_40,
    Yelowness_100,
    Flexibility
}

namespace LabBook_WF_EF.Service
{
    class NormResultService
    {
        public NormDto GetNormResult(long labbookId, int position, int pageNumber, string testName)
        {
            NormDto normDto = new NormDto();

            NormTests testType = NormTests.Empty;
            if (Enum.IsDefined(typeof(NormTests), testName))
            {
                testType = (NormTests)Enum.Parse(typeof(NormTests), testName);
            }

            switch (testType)
            {
                case NormTests.Adhession:
                    normDto.TabName = "Przyczepność";
                    AddAdhession(normDto, labbookId, position, pageNumber);
                    break;
                case NormTests.Anti_Flash:
                    normDto.TabName = "Korozja";
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Flash korozja", "Wewnętrzna", "Stal"));
                    break;
                case NormTests.Clemens:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Odporność na zarysowanie", "ISO 1518-1", "Stal"));
                    break;
                case NormTests.Condensation_chamber:
                    normDto.TabName = "Korozja";
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Komora kondensacyjna", "ISO 6270", "Stal"));
                    break;
                case NormTests.Cone_plate:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Lepkość ICI", "ISO 2884-1", ""));
                    break;
                case NormTests.Drying_time:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Czas schnięcia", "ISO 9117", "Leneta"));
                    break;
                case NormTests.Flexibility:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Zginanie", "ISO 6860", "Aluminium"));
                    break;
                case NormTests.Flow_limit:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Spływność grzebień", "ISO 2431", "Leneta"));
                    break;
                case NormTests.Gloss:
                    normDto.TabName = "Połysk";
                    AddGloss(normDto, labbookId, position, pageNumber);
                    break;
                case NormTests.Hiding:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Krycie", "ISO 2814", "Leneta"));
                    break;
                case NormTests.Hiding_power:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Wydajność przy 98%", "ISO 6504-1", "Leneta"));
                    break;
                case NormTests.Salt_chamber:
                    normDto.TabName = "Korozja";
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Komora solna", "ISO 9227", "Stal"));
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Komora solna", "ISO 9227", ""));
                    break;
                case NormTests.Scrubing:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Szorowanie", "ISO 11998", "Folia"));
                    break;
                case NormTests.Solids:
                    normDto.TabName = "Skład";
                    AddComposition(normDto, labbookId, position, pageNumber);
                    break;
                case NormTests.Stains:
                    normDto.TabName = "Plamy";
                    AddStains(normDto, labbookId, position, pageNumber);
                    break;
                case NormTests.UV_chamber:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Komora UV", "Własne", ""));
                    break;
                case NormTests.Vapour_permeablitiy:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Paroprzepuszczalność", "ISO 7783-2", ""));
                    break;
                case NormTests.Visual_aspect:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Wygląd w opakowaniu", "ISO 1513", ""));
                    break;
                case NormTests.Yelowness_100:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Żółknięcie 100oC", "Własne", "Stal"));
                    break;
                case NormTests.Yelowness_40:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Żółknięcie 40oC", "Własne", "Leneta"));
                    break;
                default:
                    normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "", "", ""));
                    break;
            }

            return normDto;
        }

        private void AddAdhession(NormDto normDto, long labbookId, int position, int pageNumber)
        {
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Cement"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Beton"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Płytka ścienna"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Karton-gips"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Stal"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Stal nierdzewna"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Aluminium"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Miedź"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Stary alkid poł."));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Stary akryl satyn"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Szkło"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Drewno lakier."));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Sosna"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Dąb"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Melamina"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", "Laminat"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Przyczepność", "ISO 2409", ""));
        }

        private void AddGloss(NormDto normDto, long labbookId, int position, int pageNumber)
        {
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Połysk 20", "ISO 2813", "Leneta"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Połysk 60", "ISO 2813", "Leneta"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Połysk 85", "ISO 2813", "Leneta"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Połysk 20", "ISO 2813", "Szkło"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Połysk 60", "ISO 2813", "Szkło"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Połysk 85", "ISO 2813", "Szkło"));
        }

        private void AddComposition(NormDto normDto, long labbookId, int position, int pageNumber)
        {
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Części stałe %", "ISO 3251", ""));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Piec 450oC %", "Własne", ""));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Piec 900oC %", "Własne", ""));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Części organiczne %", "Własne", ""));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Kreda %", "Własne", ""));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Tytan %", "Własne", ""));
        }

        private void AddStains(NormDto normDto, long labbookId, int position, int pageNumber)
        {
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Kawa 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Herbata 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Musztarda 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Sok pom. 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Ketchup 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Cola 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Olej 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Ocet 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Wina 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Mydło 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Cilit Bang 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Odkamieniacz 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Wybielacz 6% 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Błoto 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "... 2h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Kawa 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Herbata 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Musztarda 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Sok pom. 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Ketchup 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Cola 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Olej 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Ocet 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Wina 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Mydło 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Cilit Bang 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Odkamieniacz 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "Wybielacz 6% 24h", "ISO 2812-2", "PCV"));
            normDto.AddNew(new ExpNormResult(labbookId, position++, pageNumber, "... 24h", "ISO 2812-2", "PCV"));
        }
    }
}
