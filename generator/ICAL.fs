module ICAL

open System

module StrFormat =
    [<Literal>]
    let header = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:-//IC//NONSGML//EN
CALSCALE:GREGORIAN
"

    [<Literal>]
    let event = @"BEGIN:VEVENT
DTSTART;VALUE=DATE:{0:yyyyMMdd}
DTEND;VALUE=DATE:{1:yyyyMMdd}
CREATED:{2:yyyyMMddThhmmssZ}
SUMMARY:{3}
STATUS:CONFIRMED
TRANSP:TRANSPARENT
END:VEVENT
"

    [<Literal>]
    let footer = "END:VCALENDAR"

let generate (intervalName : string) (listDates : seq<int * DateTime * DateTime>) =
    let createdDate = DateTime.UtcNow
    let third (_, _, c) = c
    let getTitle = sprintf "%s %d"

    let getDetails interval =
        let (i, s, e) = interval
        String.Format(StrFormat.event, s, e, createdDate, (getTitle intervalName i))

    // string of all events
    let events =
        listDates
        |> Seq.map (fun x -> (getDetails x))
        |> Seq.reduce (+)

    // build complete events with header + footer
    StrFormat.header + events + StrFormat.footer