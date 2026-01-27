$ModelName = "RoLlama3.1-8b-Instruct-DPO-GGUF"
$GGUFUrl = "https://huggingface.co/mradermacher/RoLlama3.1-8b-Instruct-DPO-GGUF/resolve/main/RoLlama3.1-8b-Instruct-DPO.Q4_K_M.gguf?download=true"
$GGUFFile = "RoLlama3.1-8b-Instruct-DPO.Q4_K_M.gguf"
$ModelDir = "ollama_models"

if (-not (Test-Path $ModelDir)) {
    New-Item -ItemType Directory -Path $ModelDir | Out-Null
}

Write-Host "1. Downloading Romanian LLM to ./$ModelDir/..." -ForegroundColor Cyan
if (-not (Test-Path "$ModelDir\$GGUFFile")) {
    Write-Host "   Downloading ~5GB file, please wait..." -ForegroundColor Yellow
    Invoke-WebRequest -Uri $GGUFUrl -OutFile "$ModelDir\$GGUFFile"
} else {
    Write-Host "   File already exists, skipping download." -ForegroundColor Yellow
}

Write-Host "2. Creating Modelfile..." -ForegroundColor Cyan
$ModelfileContent = @"
FROM /models/$GGUFFile
TEMPLATE """{{ if .System }}<|start_header_id|>system<|end_header_id|>

{{ .System }}<|eot_id|>{{ end }}{{ if .Prompt }}<|start_header_id|>user<|end_header_id|>

{{ .Prompt }}<|eot_id|>{{ end }}<|start_header_id|>assistant<|end_header_id|>

{{ .Response }}<|eot_id|>"""
PARAMETER stop "<|start_header_id|>"
PARAMETER stop "<|end_header_id|>"
PARAMETER stop "<|eot_id|>"
"@
Set-Content -Path "$ModelDir\Modelfile" -Value $ModelfileContent

Write-Host "3. Starting Ollama Container..." -ForegroundColor Cyan
docker-compose up -d ollama
Start-Sleep -Seconds 5

Write-Host "4. Creating Model inside Docker: $ModelName..." -ForegroundColor Cyan
docker exec bacpebune-ollama ollama create $ModelName -f /models/Modelfile

Write-Host "5. Cleanup..." -ForegroundColor Cyan
Remove-Item "$ModelDir\Modelfile"

Write-Host "Success! Model installed in Docker." -ForegroundColor Green
Write-Host "Run 'docker-compose up' to start the full app." -ForegroundColor Green
