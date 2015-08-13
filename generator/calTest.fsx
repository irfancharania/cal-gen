open System

type Span =
    | Span of TimeSpan
    static member (+) (d : DateTime, Span wrapper) = d + wrapper
    static member Zero = Span(new TimeSpan(0L))

let week = TimeSpan.FromDays(7.0)
let getWeeksList (startDate : DateTime) (until : DateTime) = [ startDate..Span(week)..until ]
let startDate = DateTime.Now
let endDate = startDate.AddMonths(12).AddDays(7.0)
let datesList = startDate
                |> getWeeksList
                <| endDate
let getMonth (startDate : DateTime) (current : DateTime) =
    ((current.Year - startDate.Year) * 12) + current.Month - startDate.Month

datesList
|> List.iteri (fun i x -> printfn "Week %d / Month %d: %s" (i + 1) ((getMonth (datesList.Head) x) + 1) (x.ToString()))