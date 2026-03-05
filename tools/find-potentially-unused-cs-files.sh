#!/usr/bin/env bash
set -euo pipefail

# Basit ve hızlı bir "potansiyel" kullanılmayan dosya taraması.
# Not: Reflection / dynamic kullanımını tespit edemez, manuel kontrol gerekir.

repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$repo_root"

tmp_file="$(mktemp)"
trap 'rm -f "$tmp_file"' EXIT

rg --files -g '*.cs' > "$tmp_file"

while IFS= read -r file; do
  class_name="$(basename "$file" .cs)"

  # Program.cs, Startup, Migration vb. dosyalar yalancı pozitif üretebilir; raporlayıp manuel ele.
  count="$(rg -n "\\b${class_name}\\b" --glob '*.cs' | wc -l | tr -d ' ')"

  if [[ "$count" -le 1 ]]; then
    echo "$file"
  fi
done < "$tmp_file"
