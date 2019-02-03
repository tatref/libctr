#!/bin/bash

set -eu



if ! type ksc > /dev/null 2>&1
then
  if [ -e ./kaitai-struct-compiler-0.8/bin/kaitai-struct-compiler ]
  then
    KSC=./kaitai-struct-compiler-0.8/bin/kaitai-struct-compiler
  else
    echo "ksc not found, install kaitai-struct first"
    exit 1
  fi
else
  KSC=ksc
fi


# graphviz
echo "graphviz..."

mkdir -p graphviz
rm -rf graphviz/*
for ksy in kaitai-struct/*.ksy
do
  echo $ksy
  $KSC $ksy \
    --target graphviz \
    --import-path kaitai-struct/ \
    --outdir graphviz
done
if type dot > /dev/null 2>&1
then
  for dot in graphviz/*.dot
  do
    echo $dot
    dot -Tpng $dot -o ${dot%%.dot}.png
  done
else
  echo "dot (graphviz) not found, skipping .png generation"
fi


# csharp
echo "csharp..."

mkdir -p csharp/ctr
rm -rf csharp/ctr/*

for ksy in kaitai-struct/*.ksy
do
  echo $ksy
  $KSC $ksy \
	  --target csharp \
	  --import-path kaitai-struct/ \
	  --outdir csharp/ctr \
	  --dotnet-namespace ctr
done


# python
echo "python..."

mkdir -p python/ctr
rm -rf python/ctr/*
touch python/ctr/__init__.py

for ksy in kaitai-struct/*.ksy
do
  echo $ksy
  $KSC $ksy \
	  --target python \
	  --import-path kaitai-struct/ \
	  --outdir python/ctr \
	  --python-package ctr
done


# TODO: perl
# TODO: java
# TODO: go
# TODO: cpp_stl
# TODO: php
# TODO: lua
# TODO: ruby
# TODO: javascript

