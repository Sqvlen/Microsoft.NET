using System.Text;
using Routes.Infrastructure.Database.Abstractions;

namespace Routes.RestApi.Extensions;

public class MenuExtensions(
    ICityRepository cityRepository,
    IRouteRepository routeRepository,
    ITrolleybusRepository trolleybusRepository,
    IStopRepository stopRepository)
{
    public void Open()
    {
        var stringBuilder = new StringBuilder();
        do
        {
            stringBuilder.Clear();
            Console.WriteLine(
                "1. Отримання усіх міст\n2. Отримати місто, з найбільшою кількістю шляхів\n3. Отримати маршрути, де час проїзду понад 30 хвилин\n4. Отримати маршрути, які курсують через зупинку \"Майдан Незалежності\"\n5. Отримати маршрути, де курсує понад 5 тролейбусів\n6. Отримати список номерів тролейбусів, що курсують на маршруті \u211610\n7. Отримати маршрути, де час проїзду менше ніж 50 хвилин і курсує понад 3 тролейбусів\n8. Отримати список унікальних номерів тролейбусів, що курсують на всіх маршрутах\n9. Отримати маршрути, де час проїзду понад 30 хвилин, згруповані за кількістю тролейбусів на маршруті\n10. Отримати маршрути, де час проїзду понад 30 хвилин, згруповані за кількістю тролейбусів на маршруті, з кількістю маршрутів у кожній групі\n11. Отримати маршрути, відсортовані за часом проїзду\n12. Отримати тролейбус, з найбільшою кількістю шляхів\n13. Отримати маршрути, де час проїзду менше ніж 25 хвилин і курсує понад 2 тролейбусів, відсортовані за часом проїзду\n14. Отримати загальну кількість тролейбусів у місті\n15. Відсортувати усі зупинки за ім’ям\n16. Отримати маршрути, де курсує тролейбус \u211612 та пропустити перші 2 маршрути\n17. Отримати маршрути з часом проїзду понад 30 хвилин, згруповані за кількістю тролейбусів, з: назвами початкової та кінцевої зупинок; середнім часом проїзду; найдовшим маршрутом у кожній групі\n18. Отримати маршрути, де курсує понад 3 тролейбусів, з: середнім часом проїзду\n19. Отримати топ-5 найдовших маршрутів, час проїзду понад 30 хвилин\n20. Отримати суму часу проїзду всіх маршрутів\n");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("1. Отримання усіх міст\n");
                    var cities = cityRepository.GetAll()?.ToList();
                    cities?.ForEach(x => x.Routes?.ForEach(t => stringBuilder.Append($"{x.Name} - {t.Name}\n")));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "2":
                    Console.WriteLine("Отримати місто, з найбільшою кількістю шляхів: \n");
                    var city = cityRepository.GetCityWithLargestNumberRoutes();
                    Console.WriteLine(city?.Name + "\n");
                    break;
                case "3":
                    Console.WriteLine("Отримати маршрути, де час проїзду понад 30 хвилин\n");
                    var routes = routeRepository.GetRoutesWhereTravelTimeMoreThan(30);
                    routes?.ForEach(x => stringBuilder.Append($"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "4":
                    Console.WriteLine("Отримати маршрути, які курсують через зупинку 'Майдан Незалежності': \n");
                    routes = routeRepository.GetRoutesThatRunThroughStop("Майдан Незалежності");
                    routes?.ForEach(x => stringBuilder.Append($"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "5":
                    Console.WriteLine("Отримати маршрути, де курсує понад 5 тролейбусів: \n");
                    routes = routeRepository.GetRoutesWithTrolleybusesMoreThan(5);
                    routes?.ForEach(x => stringBuilder.Append($"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "6":
                    Console.WriteLine("Отримати список номерів тролейбусів, що курсують на маршруті \u21165\n");
                    var trolleybuses = trolleybusRepository.GetTrolleybusesInRoute(5);
                    trolleybuses?.ForEach(x => stringBuilder.Append($"Number: {x}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "7":
                    Console.WriteLine(
                        "Отримати маршрути, де час проїзду менше ніж 50 хвилин і курсує понад 3 тролейбусів\n");
                    routes = routeRepository.GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThan(50, 3);
                    routes?.ForEach(x => stringBuilder.Append($"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "8":
                    Console.WriteLine(
                        "Отримати список унікальних номерів тролейбусів, що курсують на всіх маршрутах\n");
                    var uniqueNumbers = trolleybusRepository.GetUniqueTrolleybusNumbers();
                    uniqueNumbers?.ForEach(x => stringBuilder.Append($"Number: {x}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "9":
                    Console.WriteLine(
                        "Отримати маршрути, де час проїзду понад 30 хвилин, згруповані за кількістю тролейбусів на маршрут\n");
                    var q9 = routeRepository.GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRoute(30);
                    q9.ForEach(x => x.Routes.ForEach(t => stringBuilder.Append($"{x.NumberTrolleybus} - {t.Name}\n")));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "10":
                    Console.WriteLine(
                        "Отримати маршрути, де час проїзду понад 30 хвилин, згруповані за кількістю тролейбусів на маршруті, з кількістю маршрутів у кожній групі\n");
                    var q10 = routeRepository
                        .GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRouteAndNumberRoutesInGroup(
                            30);
                    q10.ForEach(x => stringBuilder.Append($"{x.NumberTrolleybus} - {x.RouteCount}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "11":
                    Console.WriteLine("Отримати маршрути, відсортовані за часом проїзду\n");
                    routes = routeRepository.GetRoutesSortedByTravelTime();
                    routes?.ForEach(x => stringBuilder.Append($"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "12":
                    Console.WriteLine("Отримати тролейбус, з найбільшою кількістю шляхів\n");
                    var trolleybus = trolleybusRepository.GetTrolleybusWithLargestNumberRoutes();
                    Console.WriteLine($"{trolleybus?.Number} - {trolleybus?.Routes?.Count}");
                    break;
                case "13":
                    Console.WriteLine(
                        "Отримати маршрути, де час проїзду менше ніж 25 хвилин і курсує понад 2 тролейбусів, відсортовані за часом проїзду\n");
                    routes = routeRepository
                        .GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThanAndSortedByTravelTime(25, 2);
                    routes?.ForEach(x => stringBuilder.Append($"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "14":
                    Console.WriteLine(
                        "Отримати загальну кількість тролейбусів у місті: \n");
                    var numberTrolleybuses = trolleybusRepository.GetNumberTrolleybusesByCity("Миколаїв");
                    Console.WriteLine(numberTrolleybuses);
                    break;
                case "15":
                    Console.WriteLine(
                        "Відсортувати усі зупинки за ім’ям\n");
                    var stops = stopRepository.GetStopsAndSortedByName();
                    stops?.ForEach(x => stringBuilder.Append($"{x.StopName}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "16":
                    Console.WriteLine(
                        "Отримати маршрути, де курсує тролейбус \u211612 та пропустити перші 2 маршрути\n");
                    routes = routeRepository.GetRoutesWhereTrolleybusAndSkip(12, 2);
                    routes?.ForEach(x => stringBuilder.Append($"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "17":
                    Console.WriteLine(
                        "Отримати маршрути з часом проїзду понад 30 хвилин, згруповані за кількістю тролейбусів, з: назвами початкової та кінцевої зупинок; середнім часом проїзду; найдовшим маршрутом у кожній групі\n");
                    var q17 = routeRepository
                        .GetRoutesWithTravelTimeMoreThanAndGroupedByNumberOfTrolleybusesWithNameOfStartingAndEndingStopsAndAverageTravelTimeAndLongestRouteInGroup(
                            30, "Майдан Незалежності", "Лук'яновська");
                    q17?.ForEach(x => x.Routes.ForEach(t => stringBuilder.Append($"{x.TrolleybusNumber} | {x.LongestRoute?.Name} - longest\n{t.RouteName} - {t.AverageTravelTime}\n")));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "18":
                    Console.WriteLine("Отримати маршрути, де курсує понад 3 тролейбусів, з: середнім часом проїзду\n");
                    var q18 = routeRepository.GetRoutesWithTrolleybusesMoreThanAndAverageTravelTime(3);
                    q18?.ForEach(x => stringBuilder.Append($"{x.RouteName} - {x.AverageTravelTime}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "19":
                    Console.WriteLine("Отримати топ-5 найдовших маршрутів, час проїзду понад 30 хвилин\n");
                    routes = routeRepository.GetRoutesWhereTravelTimeMoreThanAndTake(30, 5);
                    routes?.ForEach(x => stringBuilder.Append($"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    Console.WriteLine(stringBuilder.ToString());
                    break;
                case "20":
                    Console.WriteLine("Отримати суму часу проїзду всіх маршрутів:\n");
                    var sumOfTravelTime = routeRepository.GetSumTravelTime();
                    Console.WriteLine(sumOfTravelTime);
                    break;
            }
        } while (true);
    }
}