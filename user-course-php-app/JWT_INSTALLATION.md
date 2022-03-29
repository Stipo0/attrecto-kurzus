### Lépések ###

# Terminál utasítások#
# Végrehajtás a felsorolás sorrendjében #
 - composer remove tymon/jwt-auth
 - composer require php-open-source-saver/jwt-auth
 - php artisan vendor:publish --provider=  ”PHPOpenSourceSaver\JWTAuth\Providers\LaravelServiceProvider”
 - php artisan jwt:secret

# Fájl módosítások#

[config\jwt.php]
# Kiegészítés az alábbi elemmel #
'guards' => [
        'api'=>[
            'driver'=> 'jwt',
            'provider' => 'users',
        ],
    ],


