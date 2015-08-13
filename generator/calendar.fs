module calendar

open System

let getCalendar intervalType intervalNumber inputDate occurrences =
    let listDates = DateGen.getDateList intervalType intervalNumber inputDate occurrences
    match listDates with
    | Some interval -> ICAL.generate (string intervalType) interval
    | None -> "Invalid input"