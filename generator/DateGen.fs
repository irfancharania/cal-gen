module DateGen

open System

/// Interval type. Value signifies calendar start
type IntervalEnum = 
    | Month = 0
    | Week = 1

/// Interval ## begins on Date, generate ## occurences
let getDateList (intervalType : IntervalEnum) (intervalNumber : int) (inputDate : DateTime) (occurences : int) = 
    let valid = intervalNumber >= (int intervalType)
    match valid with
    | false -> None
    | true -> 
        /// Interval ## begins on Date
        let calculateCalendarStart (intervalType : IntervalEnum) (intervalNumber : int) (inputDate : DateTime) = 
            match intervalType, intervalNumber = (int intervalType) with
            | _, true -> inputDate
            | IntervalEnum.Week, false -> inputDate.AddDays(-1.0 * 7.0 * float (intervalNumber - (int intervalType)))
            | IntervalEnum.Month, false -> inputDate.AddMonths(-1 * intervalNumber)
            | _ -> inputDate
        
        /// Generate list of date tuples from arbitrary start date
        let calculateIntervalList (intervalType : IntervalEnum) (startDate : DateTime) (occurences : int) = 
            let getDate (num : int) = 
                match intervalType with
                | IntervalEnum.Week -> startDate.AddDays(float (num) * 7.0)
                | IntervalEnum.Month -> startDate.AddMonths(num)
                | _ -> startDate
            
            let upto = occurences - (int intervalType)
            { 0..upto } |> Seq.map (fun x -> 
                               let intervalNum = x + (int intervalType)
                               let sdt = getDate <| x
                               let edt = getDate <| x + 1
                               (intervalNum, sdt, edt))
        
        let startDate = calculateCalendarStart intervalType intervalNumber inputDate
        let dateList = calculateIntervalList intervalType startDate occurences
        Some dateList
