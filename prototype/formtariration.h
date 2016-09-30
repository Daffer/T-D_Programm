#ifndef FORMTARIRATION_H
#define FORMTARIRATION_H

#include <QDialog>
#include <string>
#include <QListWidgetItem>

struct Tariration{
    double value;
};

namespace Ui {
class FormTariration;
}

class FormTariration : public QDialog
{
    Q_OBJECT
    
public:
    explicit FormTariration(QWidget *parent = 0);
    ~FormTariration();
signals:
    void send_tar_data(double rate);
private slots:
   // void on_pushButton_clicked();

    void on_listWidget_itemActivated(QListWidgetItem *item);

    void on_listWidget_itemClicked(QListWidgetItem *item);

    void on_pushButton_2_clicked();

    void on_pushButton_3_clicked();

private:
    Ui::FormTariration *ui;
    Tariration tarirations[200];
    int count_tar;
};

#endif // FORMTARIRATION_H
