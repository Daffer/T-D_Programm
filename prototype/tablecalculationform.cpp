#include "tablecalculationform.h"
#include "ui_tablecalculationform.h"

TableCalculationForm::TableCalculationForm(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::TableCalculationForm)
{
    ui->setupUi(this);
}

TableCalculationForm::~TableCalculationForm()
{
    delete ui;
}
void TableCalculationForm::closeEvent(QCloseEvent *cl){
    //ui->tableWidget->setRowCount(0);
    //ui->tableWidget->setColumnCount(0);
    emit closed();
    close();
}

void TableCalculationForm::receive_particles(TParticle *particles,int num)
{
    int i,j;
    ui->tableWidget->setRowCount(num);
    for (i=0;i<num;i++)
    {
        QTableWidgetItem *pt=0;
        pt=new QTableWidgetItem(QString("%1").arg(i+1));
        ui->tableWidget->setItem(i,0,pt);
        pt=new QTableWidgetItem(QString("%1").arg(particles[i].get_square()));
        ui->tableWidget->setItem(i,1,pt);
        pt=new QTableWidgetItem(QString("%1").arg(particles[i].get_perimetr()));
        ui->tableWidget->setItem(i,2,pt);
        pt=new QTableWidgetItem(QString("%1").arg(particles[i].get_length()));
        ui->tableWidget->setItem(i,3,pt);
        pt=new QTableWidgetItem(QString("%1").arg(particles[i].get_width()));
        ui->tableWidget->setItem(i,4,pt);
        pt=new QTableWidgetItem(QString("%1").arg(particles[i].get_smoothness()));
        ui->tableWidget->setItem(i,5,pt);
        pt=new QTableWidgetItem(QString("%1").arg(particles[i].get_form_factor()));
        ui->tableWidget->setItem(i,6,pt);
        pt=new QTableWidgetItem(QString("%1").arg(particles[i].get_diameter()));
        ui->tableWidget->setItem(i,7,pt);
        pt=new QTableWidgetItem(QString("%1").arg(particles[i].get_diameterGOST()));
        ui->tableWidget->setItem(i,8,pt);
    }
}
/*void TableCalculationForm::closeEvent(QCloseEvent *cl){
    delete ui;
}*/
