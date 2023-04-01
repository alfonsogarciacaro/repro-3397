module Test

#if FABLE_COMPILER
open Thoth.Json
#else
open Thoth.Json.Net
open Expecto
#endif

open Repro

let test () =
    let json =
        """
        {
            "first": "John",
            "last": "Doe"
        }
        """

    let person: Person = Decode.unsafeFromString Person.decode json
    ()

test()