#!/bin/sh

dotnet build
cd ParsePerSecond/bin/x64/Debug
zip ../../../../latest.zip ./*
