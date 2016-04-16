var gulp = require('gulp');
var browserSync = require('browser-sync');
var proxy = require('proxy-middleware');
var url = require('url');

// this task utilizes the browsersync plugin
// to create a dev server instance
// at http://localhost:9000
gulp.task('serve', ['build'], function (done) {

    var apiProxy = url.parse('http://localhost:51337/api');
    apiProxy.route = "/api";
    apiProxy.cookieRewrite = true;

    browserSync({
        online: false,
        open: false,
        port: 9000,
        server: {
            baseDir: ['./wwwroot'],
            middleware: [function(req, res, next) {
                res.setHeader('Access-Control-Allow-Origin', '*');
                next();
            }, proxy(apiProxy)]
        } 
    }, done);
});
