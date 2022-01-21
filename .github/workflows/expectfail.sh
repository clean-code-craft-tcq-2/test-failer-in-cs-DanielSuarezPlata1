#!/bin/bash

if $1 $2; then
    echo "FALSE POSITIVE! Expected failure but succeeded"
    exit 1
else
    echo "Failed as expected"
fi
