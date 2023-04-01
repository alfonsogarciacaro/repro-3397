namespace Repro

#if FABLE_COMPILER
open Thoth.Json
#else
open Thoth.Json.Net
#endif

type Person = {
    First: string
    Last: string
}

[<AutoOpen>]
module PersonExtensions =

    [<RequireQualifiedAccess>]
    module Person =

        let decode =
            Decode.object(fun get ->
                let epoch = get.Required.Field "first" Decode.string
                let timezoneId = get.Required.Field "last" Decode.string
                { Person.First = epoch; Person.Last = timezoneId }
            )

    type Person with

        static member Decode (path: string) (value: JsonValue) =
            Person.decode path value