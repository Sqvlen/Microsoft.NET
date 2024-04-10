using System.Text;
using Routes.Infrastructure.Database.Abstractions;

namespace Routes.RestApi.Extensions;

public class MenuExtensions(
    IRouteRepository routeRepository,
    ITrolleybusRepository trolleybusRepository)
{
    public void Open()
    {
        var stringBuilder = new StringBuilder();
        do
        {
            stringBuilder.Clear();
            Console.WriteLine(
                "1. Отримати усі маршрутиn\n2.Отримати маршрут з назвою\n3. Отримати маршрути, де час проїзду понад 30 хвилин\n4. Отримати маршрути, які курсують через зупинку \"Майдан Незалежності\n5. Отримати маршрути, де курсує понад 1 тролейбус\n6. Отримати маршрути, де час проїзду менше ніж 50 хвилин і курсує понад 3 тролейбусів\n7. Отримати маршрути, де час проїзду понад 30 хвилин, згруповані за кількістю тролейбусів на маршруті\n8. Отримати маршрути, де час проїзду понад 30 хвилин, згруповані за кількістю тролейбусів на маршруті, з кількістю маршрутів у кожній групі\n9. Отримати маршрути, відсортовані за часом проїзду\n10. Отримати маршрути, де час проїзду менше ніж 25 хвилин і курсує понад 2 тролейбусів, відсортовані за часом проїзду\n11. Отримати маршрути, де курсує тролейбус \u211612 та пропустити перші 2 маршрути\n12. Отримати маршрути з часом проїзду понад 30 хвилин, згруповані за кількістю тролейбусів, з: назвами початкової та кінцевої зупинок; середнім часом проїзду; найдовшим маршрутом у кожній групі\n13. Отримати маршрути, де курсує понад 3 тролейбусів, з: середнім часом проїзду\n14. Отримати топ-5 найдовших маршрутів, час проїзду понад 30 хвилин\n15. Отримати суму часу проїзду всіх маршрутів");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Отримати усі маршрутиn: \n");
                    var q1 = routeRepository.GetAll()?.ToList();
                    q1?.ForEach(x =>
                        stringBuilder.Append(
                            $"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    break;
                case "2":
                    Console.WriteLine("Отримати маршрут з назвою: \n");
                    var inputParameter = Console.ReadLine();
                    var q2 = routeRepository.GetRouteByName(inputParameter!);
                    if (q2 is not null)
                        stringBuilder.Append(
                            $"{q2.Name}|{q2.Number}: {q2.TravelTime} with {q2.Trolleybuses?.Count}. Start: {q2.StartStopEntity?.StopName}/End: {q2.EndStopEntity?.StopName}\n");
                    break;
                case "3":
                    Console.WriteLine("Отримати маршрути, де час проїзду понад 30 хвилин: \n");
                    var routes = routeRepository.GetRoutesWhereTravelTimeMoreThan(30);
                    routes?.ForEach(x =>
                        stringBuilder.Append(
                            $"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    break;
                case "4":
                    Console.WriteLine("Отримати маршрути, які курсують через зупинку: \n");
                    inputParameter = Console.ReadLine();
                    routes = routeRepository.GetRoutesThatRunThroughStop(inputParameter!);
                    routes?.ForEach(x =>
                        stringBuilder.Append(
                            $"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    break;
                case "5":
                    Console.WriteLine("Отримати маршрути, де курсує понад n тролейбусів: \n");
                    inputParameter = Console.ReadLine();
                    routes = routeRepository.GetRoutesWithTrolleybusesMoreThan(int.Parse(inputParameter!));
                    routes?.ForEach(x =>
                        stringBuilder.Append(
                            $"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    break;
                case "6":
                    Console.WriteLine(
                        "Отримати маршрути, де час проїзду менше ніж 50 хвилин і курсує понад 3 тролейбусів\n");
                    routes = routeRepository.GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThan(50, 3);
                    routes?.ForEach(x =>
                        stringBuilder.Append(
                            $"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    break;
                case "7":
                    Console.WriteLine(
                        "Отримати маршрути, де час проїзду понад 30 хвилин, згруповані за кількістю тролейбусів на маршрут\n");
                    var q9 = routeRepository.GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRoute(30);
                    q9.ForEach(x => x.Routes.ForEach(t => stringBuilder.Append($"{x.NumberTrolleybus} - {t.Name}\n")));
                    break;
                case "8":
                    Console.WriteLine(
                        "Отримати маршрути, де час проїзду понад 30 хвилин, згруповані за кількістю тролейбусів на маршруті, з кількістю маршрутів у кожній групі\n");
                    var q10 = routeRepository
                        .GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRouteAndNumberRoutesInGroup(
                            30);
                    q10.ForEach(x => stringBuilder.Append($"{x.NumberTrolleybus} - {x.RouteCount}\n"));
                    break;
                case "9":
                    Console.WriteLine("Отримати маршрути, відсортовані за часом проїзду\n");
                    routes = routeRepository.GetRoutesSortedByTravelTime();
                    routes?.ForEach(x =>
                        stringBuilder.Append(
                            $"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    break;
                case "10":
                    Console.WriteLine(
                        "Отримати маршрути, де час проїзду менше ніж 30 хвилин і курсує понад 2 тролейбусів, відсортовані за часом проїзду\n");
                    routes = routeRepository
                        .GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThanAndSortedByTravelTime(30, 2);
                    routes?.ForEach(x =>
                        stringBuilder.Append(
                            $"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    break;
                case "11":
                    Console.WriteLine(
                        "Отримати маршрути, де курсує тролейбус \u211612 та пропустити перші 2 маршрути\n");
                    routes = routeRepository.GetRoutesWhereTrolleybusAndSkip(12, 2);
                    routes?.ForEach(x =>
                        stringBuilder.Append(
                            $"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    break;
                case "12":
                    Console.WriteLine(
                        "Отримати маршрути з часом проїзду понад 30 хвилин, згруповані за кількістю тролейбусів, з: назвами початкової та кінцевої зупинок; середнім часом проїзду; найдовшим маршрутом у кожній групі\n");
                    var q12 = routeRepository
                        .GetRoutesWithTravelTimeMoreThanAndGroupedByNumberOfTrolleybusesWithNameOfStartingAndEndingStopsAndAverageTravelTimeAndLongestRouteInGroup(
                            30, "Майдан Незалежності", "Лук'яновська");
                    q12.ForEach(x => x.Routes.ForEach(t =>
                        stringBuilder.Append(
                            $"{x.TrolleybusNumber} | {x.LongestRoute?.Name} - longest\n{t.RouteName} - {t.AverageTravelTime}\n")));
                    break;
                case "13":
                    Console.WriteLine("Отримати маршрути, де курсує понад 3 тролейбусів, з: середнім часом проїзду\n");
                    var q18 = routeRepository.GetRoutesWithTrolleybusesMoreThanAndAverageTravelTime(3);
                    q18?.ForEach(x => stringBuilder.Append($"{x.RouteName} - {x.AverageTravelTime}\n"));
                    break;
                case "14":
                    Console.WriteLine("Отримати топ-5 найдовших маршрутів, час проїзду понад 30 хвилин\n");
                    routes = routeRepository.GetRoutesWhereTravelTimeMoreThanAndTake(30, 5);
                    routes.ForEach(x =>
                        stringBuilder.Append(
                            $"{x.Name}|{x.Number}: {x.TravelTime} with {x.Trolleybuses?.Count}. Start: {x.StartStopEntity?.StopName}/End: {x.EndStopEntity?.StopName}\n"));
                    break;
                case "15":
                    Console.WriteLine("Отримати суму часу проїзду всіх маршрутів:\n");
                    var sumOfTravelTime = routeRepository.GetSumTravelTime();
                    Console.WriteLine(sumOfTravelTime);
                    break;
                case "16":
                    Console.WriteLine();
                    trolleybusRepository.GetJsonNode();
                    var q16 = trolleybusRepository.GetTrolleybusWithLargestNumberRoutes();
                    if (q16 is not null)
                        stringBuilder.Append($"{q16.Id}|{q16.Number}");
                    break;
            }

            Console.WriteLine(stringBuilder.ToString());
        } while (true);
    }
}