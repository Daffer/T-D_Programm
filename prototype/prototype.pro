#-------------------------------------------------
#
# Project created by QtCreator 2015-10-19T15:47:38
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = prototype
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    image.cpp \
    form.cpp \
    formbinarization.cpp \
    tparticle.cpp \
    tablecalculationform.cpp \
    formbrightness.cpp \
    formtariration.cpp

HEADERS  += mainwindow.h \
    image.h \
    form.h \
    formbinarization.h \
    tparticle.h \
    tablecalculationform.h \
    formbrightness.h \
    formtariration.h

FORMS    += mainwindow.ui \
    form.ui \
    formbinarization.ui \
    tablecalculationform.ui \
    formbrightness.ui \
    formtariration.ui
