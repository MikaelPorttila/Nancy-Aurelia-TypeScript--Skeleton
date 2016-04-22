# Resolve npm and jspm packages.
# Transcompile typescript files.
# bundle and minify

write-host "[Deployment setup] Begin"

$root = $PSScriptRoot

Set-Location $root
$wwwroot = $root + "\wwwroot"

# NPM INSTALL
npm set progress=false
$res = npm install 2>&1
$errs = ($res | ? { $_.gettype().Name -eq "ErrorRecord" -and $_.Exception.Message.ToLower().Contains("err") })
if ($errs.Count -gt 0) {
    $errs | % { Write-Error $_ }
    exit 1
} 

# jspm INSTALL
Write-Host "[jspm] install begin"
$res = jspm install -y 2>&1
$errs = ($res | ? { $_.gettype().Name -eq "ErrorRecord" -and $_.Exception.Message.ToLower().Contains("err") })
if ($errs.Count -gt 0) {
    $errs | % { Write-Error $_ }
    exit 1
} 
Write-Host "[jspm] install completed"

# Gulp
Write-Host "[Bundling] Begin"
node_modules\.bin\gulp.cmd bundle
Write-Host "[Bundling] completed"

Write-Host "[Deployment setup] completed"