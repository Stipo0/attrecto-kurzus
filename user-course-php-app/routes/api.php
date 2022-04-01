<?php

use App\Http\Controllers\AuthController;
use App\Http\Controllers\CourseController;
use App\Http\Controllers\FrameworkController;
use App\Http\Controllers\UserController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

//Órai//

/*Course*/
/*Auth*/
Route::group([
    'prefix' => 'courses'
], function ($router) {

    Route::get('', [CourseController::class, 'index']);
    Route::get('{id}', [CourseController::class, 'show']);
    Route::post('',[CourseController::class,'store']);
    Route::delete('{course}',[CourseController::class,'destroy']);
    Route::put('{course}',[CourseController::class,'update']);

    Route::put('{course}', [CourseController::class, 'update2']);
});



/*User*/
Route::post('/users/registration', [UserController::class,'store']);
Route::put('/users/{user}', [UserController::class, 'update']);


/*Auth*/
Route::group([
    'prefix' => 'auth'
], function ($router) {

    Route::group(['middleware' => ['auth:api']], function () {
        Route::get('me', [AuthController::class, 'me']);
        Route::post('logout', [AuthController::class, 'logout']);
        Route::post('refresh', [AuthController::class, 'refresh']);
    });
    Route::post('login', [AuthController::class, 'login']);
});

//Szorgalmi//

/*Framework*/
Route::get('/frameworks', [FrameworkController::class, 'index']);
Route::get('/frameworks/{id}', [FrameworkController::class, 'show']);
Route::post('/frameworks',[FrameworkController::class,'store']);
Route::delete('/frameworks/{framework}',[FrameworkController::class,'destroy']);
Route::put('/frameworks/{framework}',[FrameworkController::class,'update']);
