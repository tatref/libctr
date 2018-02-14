#!/bin/bash

set -eu


if ! type ksc > /dev/null 2>&1
then
  echo "ksc not found, install kaitai-struct first"
  exit 1
fi


# graphviz
echo "graphviz..."

mkdir -p graphviz
for ksy in formats_specifications/*.ksy
do
  ksc $ksy \
    --target graphviz \
    --import-path formats_specifications/ \
    --outdir graphviz
done
if type dot > /dev/null 2>&1
then
  for dot in graphviz/*.dot
  do
    dot -Tpng $dot -o ${dot%%.dot}.png
  done
else
  echo "dot (graphviz) not found, skipping .png generation"
fi


# TODO: csharp
# TODO: perl
# TODO: java
# TODO: go
# TODO: cpp_stl
# TODO: php
# TODO: lua
# TODO: ruby
# TODO: javascript


# python
echo "python..."

mkdir -p python/ctr
touch python/ctr/__init__.py

for ksy in formats_specifications/*.ksy
do
  ksc $ksy \
	  --target python \
	  --import-path formats_specifications/ \
	  --outdir python/ctr \
	  --python-package ctr
done

