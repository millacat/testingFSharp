

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
        else Some (sprintf "Input: %A\nExpected: %A\nActual: %A\n\n" inp exp out)
  with e -> Some (sprintf "Input: %A\nFailed with exception: %A\n\n" inp e)

(* Iterate result list and print it *)
let printTestResults (res : string option list) : unit =
    List.iter (Option.iter (printf "%s")) res

(* -------------------------------------------------------------------------- *)

printfn "\n--------------------- TESTS ------------------------- \n"

(* ---------------------------- 5i0a - isTable ------------------------------ *)
printfn ">> Test of isTable<<"

let INPUT_a  = [ [[]];
                 [];
                 [[0];[1;2]];
                 [[0;-1];[2]];
                 [[0;1;2];[3;4]];
                 [[1]];
                 [[0;1;2];[3;4;5];[6;7;8]]
               ]

let INPUT_a2 = [ [[]];
                 [];
                 [[0.];[1.;2.]];
                 [[0.;-1.];[2.]];
                 [[0.;1.;2.];[3.;4.]];
                 [[1.]];
                 [[0.;1.;2.];[3.;4.;5.];[6.;7.;8.]]
               ]

let EXPECTED_a = [false; false; false; false; false; true; true]

let tests_a = List.map2 (testFunc1 isTable) INPUT_a EXPECTED_a
printTestResults tests_a
//List.iter (Option.iter (printf "%s")) tests_a
let tests_a2 = List.map2 (testFunc1 isTable) INPUT_a2 EXPECTED_a
printTestResults tests_a2


(* ------------------------- 5i0b - firstColumn ---------------------------- *)
printfn ">> Test of firstColumn <<"

let INPUT_b  = [ [[]];
                 [];
                 [[0];[]];
                 [[0];[1;2]];
                 [[0;-1];[2]];
                 [[0;1;2];[3;4]];
                 [[1]];
                 [[0;1;2];[3;4;5];[6;7;8]]
               ]

let INPUT_b2 = [ [[]];
                 [];
                 [[0.];[]];
                 [[0.];[1.;2.]];
                 [[0.;-1.];[2.]];
                 [[0.;1.;2.];[3.;4.]];
                 [[1.]];
                 [[0.;1.;2.];[3.;4.;5.];[6.;7.;8.]]
               ]

let EXPECTED_b  = [[]; []; []; [0;1]; [0;2]; [0;3]; [1]; [0;3;6] ]
let EXPECTED_b2 = [[]; []; []; [0.;1.]; [0.;2.]; [0.;3.]; [1.]; [0.;3.;6.] ]

let tests_b = List.map2 (testFunc1 firstColumn) INPUT_b EXPECTED_b
printTestResults tests_b

let tests_b2 = List.map2 (testFunc1 firstColumn) INPUT_b2 EXPECTED_b2
printTestResults tests_b2

(* --------------------- 5i0c - dropFirstColumn ---------------------------- *)
printfn ">> Test of dropFirstColumn <<"

let INPUT_c  = [ [[0]; [0]];
                 [[0]; [1;2]];
                 [[0;-1]; [2]];
                 [[0;1;2]; [3;4]];
                 [[1]];
                 [[0;1;2]; [3;4;5]; [6;7;8]]
               ]

let INPUT_c2 = [ [[0.];[0.]];
                 [[0.];[1.;2.]];
                 [[0.;-1.];[2.]];
                 [[0.;1.;2.];[3.;4.]];
                 [[1.]];
                 [[0.;1.;2.];[3.;4.;5.];[6.;7.;8.]]
               ]

let EXPECTED_c  = [ [[];[]];
                    [[];[2]];
                    [[-1];[]];
                    [[1;2];[4]];
                    [[]];
                    [[1;2];[4;5];[7;8]]
                  ]

let EXPECTED_c2  = [ [[];[]];
                     [[];[2.]];
                     [[-1.];[]];
                     [[1.;2.];[4.]];
                     [[]];
                     [[1.;2.];[4.;5.];[7.;8.]]
                   ]
let tests_c = List.map2 (testFunc1 dropFirstColumn) INPUT_c EXPECTED_c
printTestResults tests_c
let tests_c2 = List.map2 (testFunc1 dropFirstColumn) INPUT_c2 EXPECTED_c2
printTestResults tests_c2

(* ---------------------------- 5i0d - transpose ---------------------------- *)
printfn ">> Test of transpose <<"

let INPUT_d = [ [[1;2;3];[4;5;6]]
                [[1;2;3];[4;5;6];[7;8;9]]
                [[1;2];[4;5]]
                [[1];[4]]
                [[1;2;3;4];[5;6;7;8];[9;10;11;12]]
              ]

let EXPECTED_d = INPUT_d

// Doing function composition on transpose because of:
// transpose (transpose input) = input
let tests_d = List.map2 (testFunc1 (transpose >> transpose)) INPUT_d EXPECTED_d
printTestResults tests_d

