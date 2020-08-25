#!/usr/bin/env bash

##### Created by Cami K. Dalsgaard, E2019 #####

### Run:
#           ./test_5i.sh [file].zip
# e.g.      ./test_5i.sh 5i_cami.zip
# If you already have unzipped the file then run:
#           ./test_5i.sh --no-unzip
# or        ./test_5i.sh -n


### Checking arguments to script
if [ $# -eq 0 ] # No args given
then
    echo $'Usage (including unzipping):\n\t./test_5i.sh [file].zip\n'
    echo $'Usage (without unzipping):\n\t./test_5i.sh --no-unzip
        ./test_5i.sh -n'
    exit
elif [[ $1 != '--no-unzip' ]] && [[ $1 != '-n' ]];
then
    # if zip file contains spaces, then insert underscores
    inpWOSpaces=`echo "$1" | sed -E 's/ /_/g'`
    if [[ "$1" != ${inpWOSpaces} ]];
    then
        mv "$1" ${inpWOSpaces}
    fi
    # Unpacking 1st argument
    unzip ${inpWOSpaces}
fi


### Removing MAC folder if present
if [[ -d __MACOSX ]]; then
    rm -r __MACOSX
fi

### Finding src directory and moving it to current level.
src=`ls -R | grep -E -i 'src' | sed -e 's/:.*//' | tail -1`

# Change 'mv' to 'cp -r' if you want the src dir to be copied instead of moved
mv ${src} . &>/dev/null

##### Test
### 5i0a-d: isTable, firstColumn, dropFirstColumn, transpose
echo $'\n*************'
echo $'** 5i0.fsx **'
# taking 5i0.fsx (just any file with a 0 in it) and redirecting it
cat src/*0*.fsx > setup5i0.fsx
cat _testFiles/5i0_test.fsx >> setup5i0.fsx # appending test
# Compile student code and test
fsharpc --nologo setup5i0.fsx
echo $'\n--------------- Student code execution -------------- \n'
mono setup5i0.exe

### 5i1: concat
echo $'\n\n*************'
echo $'** 5i1.fsx **'
cat src/*1*.fsx > setup5i1.fsx
cat _testFiles/5i1_test.fsx >> setup5i1.fsx
# Compile student code and test
fsharpc --nologo setup5i1.fsx
echo $'\n--------------- Student code execution -------------- \n'
mono setup5i1.exe


### Clean up
rm setup5i0.fsx setup5i0.exe setup5i1.fsx setup5i1.exe

