#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QAction>
#include <QGraphicsView>
#include <QGraphicsScene>
#include <QImage>
#include <QPixmap>
#include <QRgb>
#include <QPainter>
#include <image.h>
#include "form.h"
#include <QFileDialog>
#include <QMessageBox>
#include <formbinarization.h>
#include <tablecalculationform.h>
#include <formbrightness.h>
#include <formtariration.h>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
signals:
    void send_data(int,My_Image);
    void send_particles(TParticle *part,int num);
    
private slots:
    void on_pushButton_clicked();//otsu

    void on_pushButton_2_clicked();//erode

    void on_pushButton_3_clicked();//dilate

    void on_pushButton_4_clicked();//borders

    void on_pushButton_5_clicked();//negativ

    void create_image_form();
    void recieve_n(int x,My_Image im);//signal from active image
    void recieve_threshold(int x, My_Image im);//recieve threshold from bin form
    void recieve_data(int x,My_Image im);//recieve threshold from bin form
    void receive_br_data(int n1,int n2,My_Image im,int pr);//receive data for brightness form
    void receive_rate(double rate);//receive data from tariration form
    int check_image(int code);//check the image
    void delete_particles();
    void on_pushButton_6_clicked();//open file

    void on_pushButton_7_clicked();

    void on_pushButton_8_clicked();

    void on_pushButton_9_clicked();

    void on_pushButton_10_clicked();

    void on_pushButton_11_clicked();

private:
    Ui::MainWindow *ui;
    QGraphicsScene *scene;
    QImage im;
    My_Image img;
    Form *d[200];
    int dcount=0;
    int active_window;
    int i;
    int zagl=0;
};

#endif // MAINWINDOW_H
