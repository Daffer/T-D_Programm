#ifndef FORMBRIGHTNESS_H
#define FORMBRIGHTNESS_H

#include <QDialog>
#include "image.h"

namespace Ui {
class FormBrightness;
}

class FormBrightness : public QDialog
{
    Q_OBJECT
    
public:
    explicit FormBrightness(QWidget *parent = 0);
    ~FormBrightness();
    int n1,n2;
signals:
    void send_br_data(int n,int n2,My_Image img,int pr);
    
private slots:
    void on_horizontalSlider_valueChanged(int value);
    void set_image(int n,My_Image img);
    void on_horizontalSlider_2_valueChanged(int value);

    void on_pushButton_clicked();

    void on_pushButton_2_clicked();

    void on_horizontalSlider_2_sliderMoved(int position);

    void on_horizontalSlider_actionTriggered(int action);

    void on_horizontalSlider_sliderMoved(int position);

private:

    My_Image im;
    Ui::FormBrightness *ui;
};

#endif // FORMBRIGHTNESS_H
