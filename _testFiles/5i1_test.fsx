
(* Function to exception handle if student code crashes
 * INPUT
 *   - f   : the student function to test
 *   - inp : input to f
 *   - exp : expected output/result when executing f inp
 * RETURNS
 *   - a string option
 *)
let testFunc1 (f : 'a -> 'b) (inp : 'a) (exp : 'b) : string option =
  try
    let out = f inp
    if out = exp
        then None
        else Some (sprintf "Input:\t\t%A\nExpected:\t%A\nActual: \t%A\n\n"
                             inp exp out)
  with e -> Some (sprintf "Failed on input: %A\nwith exception: %A\n\n" inp e)

(* ---------------------------- 5i1 - concat ------------------------------- *)

let INPUT = [ [[2]; [6; 4]; [1]];
              [[]; []; []];
              [[]; [-1]; []];
              [[0]; []; []];
              [[0]; []; [-1]];
              [[1]; [2]; [3]; [4]];
              [[1;2;3]; []]
            ]

let EXPECTED = [ [2; 6; 4; 1];
                 [];
                 [-1];
                 [0];
                 [0; -1];
                 [1; 2; 3; 4];
                 [1; 2; 3]
               ]


printfn "\n--------------------- TESTS ------------------------- \n"
printfn ">> Test of concat<<"

(* making sure the type is correct in student implementation of concat *)
let _ = concat : 'a list list -> 'a list

let tests : string option list = List.map2 (testFunc1 concat) INPUT EXPECTED

List.iter (Option.iter (printf "%s")) tests


